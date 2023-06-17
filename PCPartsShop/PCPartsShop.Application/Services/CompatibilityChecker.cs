using PCPartsShop.Domain.Dtos;
using PCPartsShop.Domain.Models;
using PCPartsShop.Application.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PCPartsShop.Application.Services
{
    public class CompatibilityChecker : ICompatibilityChecker
    {
        public List<CompatibilityMessage> CheckCompatibility(List<FullSpecificationComponentDto> parts)
        {
            var messages = new List<CompatibilityMessage>();
            FullSpecificationComponentDto psu = null;
            int totalPowerAvailable = 0;
            int powerConsumption = 0;

            if (!CheckAlgorithmAvailability(parts))
            {
                messages.Clear();
                messages.Add(new CompatibilityMessage
                {
                    Component1 = null,
                    Component2 = null,
                    Summary = "Unavailable",
                    Message = "We are sorry but we cannot check the compatibility of this configuration. Make sure your cart doesn't contain multiple different Power supplies, CPUs, Motherboards, Cases or Coolers. Also we cannot check the compatibility of a system that has more than 3 GPUs or more than 4 RAM sticks.",
                    Severity = "Unavailable"
                });
                return messages;
            }

            foreach (var part1 in parts)
            {
                powerConsumption = GetPowerConsumption(powerConsumption, part1);
                foreach (var part2 in parts)
                {
                    if (part1.ComponentId == part2.ComponentId)
                    {
                        continue; // Do not check compatibility between the same component
                    }
                    switch (part1.ComponentType.ToUpper())
                    {
                        case "CPU":
                            messages = messages.Concat(CheckCPUCompatibility(part1, part2)).ToList();
                        break;
                        case "MOBO":
                            messages = messages.Concat(CheckMOBOCompatibility(part1, part2)).ToList();
                        break;
                        case "GPU":
                            messages = messages.Concat(CheckGPUCompatibility(part1, part2)).ToList();
                        break;
                        case "CASE":
                            messages = messages.Concat(CheckCaseCompatibility(part1, part2)).ToList();
                            break;
                        case "PSU":
                            totalPowerAvailable = part1.Power;
                            psu = part1;
                        break;
                    }
                }
            }

            if(totalPowerAvailable> 0)
            {
                messages = messages.Concat(CheckPSUCompatibility(totalPowerAvailable, powerConsumption, psu)).ToList();
            }

            if(messages.Count == 0)
            {
                messages.Add(new CompatibilityMessage
                {
                    Component1 = null,
                    Component2 = null,
                    Summary = "Unavailable",
                    Message = "We are sorry but we cannot check the compatibility of this configuration. Most likely your cart contains only one component or components that do not require a compatibility check.",
                    Severity = "Unavailable"
                });
            }

            return messages;
        }

        #region private methods
        private static List<CompatibilityMessage> CheckCPUCompatibility(FullSpecificationComponentDto part1, FullSpecificationComponentDto part2)
        {
            var messages = new List<CompatibilityMessage>();

            if (part2.ComponentType.ToUpper() == "MOBO")
            {
                if (part1.Socket.ToLower() == part2.Socket.ToLower())
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Compatible",
                        Message = $"{FormatStringAsCamelCase(part1.Make)} {part1.Model} is fully compatible with {FormatStringAsCamelCase(part2.Make)} {part2.Model}, regarding the socket. (Both use {part1.Socket})",
                        Severity = "Green",
                    });
                }
                else
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Incompatible",
                        Message = $"{FormatStringAsCamelCase(part1.Make)} {part1.Model} is not compatible with {FormatStringAsCamelCase(part2.Make)} {part2.Model}. They are using a different socket.",
                        Severity = "Red",
                    });
                }
            }
            if (part2.ComponentType.ToUpper() == "RAM")
            {
                if (part1.MemoryFrequency == part2.Frequency)
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Compatible",
                        Message = $"{FormatStringAsCamelCase(part1.Make)} {part1.Model} and {FormatStringAsCamelCase(part2.Make)} {part2.Model} are running at the same frequency (CPU: {part1.MemoryFrequency}, RAM: {part2.Frequency}).",
                        Severity = "Green",
                    });
                }
                else if (part1.MemoryFrequency < part2.Frequency)
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Compatible",
                        Message = $"{FormatStringAsCamelCase(part2.Make)} {part2.Model} is running at a higher frequency than {FormatStringAsCamelCase(part1.Make)} {part1.Model}, however the CPU can handle this using the XMP Profile from BIOS. (CPU: {part1.MemoryFrequency}, RAM: {part2.Frequency}).",
                        Severity = "Green",
                    });
                }
                else
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Partially compatible",
                        Message = $"{FormatStringAsCamelCase(part2.Make)} {part2.Model} is running at a lower frequency than {FormatStringAsCamelCase(part1.Make)} {part1.Model}, this can slow down the CPU. (CPU: {part1.MemoryFrequency}, RAM: {part2.Frequency}).",
                        Severity = "Amber",
                    });
                }
            }
            return messages;
        }
        private static List<CompatibilityMessage> CheckMOBOCompatibility(FullSpecificationComponentDto part1, FullSpecificationComponentDto part2)
        {
            var messages = new List<CompatibilityMessage>();

            if(part2.ComponentType.ToUpper() == "RAM")
            {
                if(part1.LowestFrequencySupported <= part2.Frequency && part2.Frequency <= part1.HighestFrequencySupported)
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Compatible",
                        Message = $"{FormatStringAsCamelCase(part1.Make)} {part1.Model} allows {FormatStringAsCamelCase(part2.Make)} {part2.Model} frequency.",
                        Severity = "Green",
                    });
                }
                else
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Incompatible",
                        Message = $"{FormatStringAsCamelCase(part1.Make)} {part1.Model} doesn't allow {FormatStringAsCamelCase(part2.Make)} {part2.Model} frequency. ({part2.Frequency})",
                        Severity = "Red",
                    });
                }

                if(part1.MemoryType.ToLower() == part2.Type.ToLower())
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Compatible",
                        Message = $"{FormatStringAsCamelCase(part1.Make)} {part1.Model} has the same memory type as {FormatStringAsCamelCase(part2.Make)} {part2.Model} ({part1.MemoryType}).",
                        Severity = "Green",
                    });
                }
                else
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Incompatible",
                        Message = $"{FormatStringAsCamelCase(part1.Make)} {part1.Model} doesn't have the same memory type as {FormatStringAsCamelCase(part2.Make)} {part2.Model} ({part1.MemoryType} differs from {part2.Type}).",
                        Severity = "Red",
                    });
                }
            }

            return messages;
        }
        private static List<CompatibilityMessage> CheckGPUCompatibility(FullSpecificationComponentDto part1, FullSpecificationComponentDto part2)
        {
            var messages = new List<CompatibilityMessage>();

            if (part2.ComponentType.ToUpper() == "PSU")
            {
                if(part1.PowerConsumption > part2.Power)
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Incompatible",
                        Message = $"{FormatStringAsCamelCase(part1.Make)} {part1.Model} is consuming more power than {FormatStringAsCamelCase(part2.Make)} {part2.Model} can provide.",
                        Severity = "Red",
                    });
                }
            }

            return messages;
        }
        private static List<CompatibilityMessage> CheckCaseCompatibility(FullSpecificationComponentDto part1, FullSpecificationComponentDto part2)
        {
            var messages = new List<CompatibilityMessage>();

            if (part2.ComponentType.ToUpper() == "GPU")
            {
                if(part1.GPUMaximumLength >= part2.Length)
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Compatible",
                        Message = $"{FormatStringAsCamelCase(part2.Make)} {part2.Model} fits into {FormatStringAsCamelCase(part1.Make)} {part1.Model}.",
                        Severity = "Green",
                    });
                }
                else
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Incompatible",
                        Message = $"{FormatStringAsCamelCase(part2.Make)} {part2.Model} cannot fit into {FormatStringAsCamelCase(part1.Make)} {part1.Model}. We recommend choosing a case with at least {part2.Length} mm of length.",
                        Severity = "Red",
                    });
                }
            }
            if (part2.ComponentType.ToUpper() == "COOLER")
            {
                if(part1.CoolerMaximumHeight >= part2.Height && part2.Height > 0)
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Compatible",
                        Message = $"{FormatStringAsCamelCase(part2.Make)} {part2.Model} fits into {FormatStringAsCamelCase(part1.Make)} {part1.Model}.",
                        Severity = "Green",
                    });
                }
                else if (part2.Height > 0)
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Incompatible",
                        Message = $"{FormatStringAsCamelCase(part2.Make)} {part2.Model} cannot fit into {FormatStringAsCamelCase(part1.Make)} {part1.Model}. We recommend choosing a case with at least {part2.Height} mm cooler height.",
                        Severity = "Red",
                    });
                }
                if(part1.RadiatorSupport && part1.RadiatorSupportLength > 0 && part2.RadiatorLength > 0 && part1.RadiatorSupportLength >= part2.RadiatorLength)
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Compatible",
                        Message = $"{FormatStringAsCamelCase(part2.Make)} {part2.Model} fits into {FormatStringAsCamelCase(part1.Make)} {part1.Model}.",
                        Severity = "Green",
                    });
                } 
                else if (part1.RadiatorSupport && part1.RadiatorSupportLength > 0 && part2.RadiatorLength > 0 && part1.RadiatorSupportLength < part2.RadiatorLength)
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Incompatible",
                        Message = $"{FormatStringAsCamelCase(part2.Make)} {part2.Model} cannot fit into {FormatStringAsCamelCase(part1.Make)} {part1.Model}. We recommend choosing a case with a radiator support of at least {part2.RadiatorLength} mm.",
                        Severity = "Red",
                    });
                }
                else if((!part1.RadiatorSupport || part1.RadiatorSupportLength == 0) && (part2.RadiatorLength > 0))
                {
                    messages.Add(new CompatibilityMessage
                    {
                        Component1 = part1,
                        Component2 = part2,
                        Summary = "Incompatible",
                        Message = $"{FormatStringAsCamelCase(part1.Make)} {part1.Model} does not have a radiator support for {FormatStringAsCamelCase(part1.Make)} {part1.Model}. We recommend choosing a case with a radiator support of at least {part2.RadiatorLength} mm.",
                        Severity = "Red",
                    });
                }
            }

            return messages;
        }
        private static List<CompatibilityMessage> CheckPSUCompatibility(int totalPower, int totalPowerConsumption, FullSpecificationComponentDto psu)
        {
            var messages = new List<CompatibilityMessage>();
            int recommendedPowerOutput = ((totalPowerConsumption / 100) + 1) * 100;

            if (totalPower <= totalPowerConsumption)
            {
                messages.Add(new CompatibilityMessage
                {
                    Component1 = psu,
                    Component2 = null,
                    Summary = "Incompatible",
                    Message = $"{FormatStringAsCamelCase(psu.Make)} {psu.Model} is generating less power than the total power consumption of the other components. We recommend choosing a power supply with at least {totalPowerConsumption+100}W.",
                    Severity = "Red",
                });
            }
            if(totalPower > totalPowerConsumption + 100)
            {
                messages.Add(new CompatibilityMessage
                {
                    Component1 = psu,
                    Component2 = null,
                    Summary = "Compatible",
                    Message = $"{FormatStringAsCamelCase(psu.Make)} {psu.Model} is powerful enough for your build.",
                    Severity = "Green",
                });
            }
            else if (totalPower > totalPowerConsumption) 
            {
                messages.Add(new CompatibilityMessage
                {
                    Component1 = psu,
                    Component2 = null,
                    Summary = "Partially compatible",
                    Message = $"{FormatStringAsCamelCase(psu.Make)} {psu.Model} is powerful enough for your build, however we recommend choosing a power supply with at least {totalPowerConsumption+100}W.",
                    Severity = "Amber",
                });
            }

            return messages;
        }

        private static string FormatStringAsCamelCase(string value)
        {
            string camelCaseString = value[0].ToString().ToUpper();
            value = value[1..];
            camelCaseString += value;

            return camelCaseString;
        }

        private static bool CheckAlgorithmAvailability(List<FullSpecificationComponentDto> parts)
        {
            int cpus, psus, mobos, cases, coolers;
            cpus = psus = mobos = cases = coolers = 0;

            foreach (var part in parts)
            {
                if (part.ComponentType.ToUpper() == "CPU")
                {
                    cpus++;
                }
                if (part.ComponentType.ToUpper() == "MOBO")
                {
                    mobos++;
                }
                if (part.ComponentType.ToUpper() == "PSU")
                {
                    psus++;
                }
                if (part.ComponentType.ToUpper() == "GPU" && part.Qty > 3)
                {
                    return false;
                }
                if (part.ComponentType.ToUpper() == "RAM" && part.Qty > 4)
                {
                    return false;
                }
                if (part.ComponentType.ToUpper() == "CASE")
                {
                    cases++;
                }
                if (part.ComponentType.ToUpper() == "COOLER")
                {
                    coolers++;
                }
            }

            if (cpus >= 2 || psus >= 2 || mobos >= 2 || cases >= 2 || coolers >= 2)
            {
                return false;
            }

            return true;
        }

        private static int GetPowerConsumption (int totalPower, FullSpecificationComponentDto part)
        {
            switch(part.ComponentType)
            {
                case "CPU":
                    totalPower += 2 * part.ThermalDesignPower;
                break;
                case "MOBO":
                    totalPower += 80;
                break;
                case "GPU":
                    totalPower += part.PowerConsumption * part.Qty;
                break;
                case "RAM":
                case "SSD":
                    totalPower += 10 * part.Qty;
                break;
            }
            return totalPower;
        }
        #endregion private methods
    }
}
