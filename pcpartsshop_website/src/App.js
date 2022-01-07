import {
  Products,
  Navbar,
  Cart,
  Checkout,
  LoginForm,
  AdminPage,
  ProfilePage,
} from "./components";
//import Cart from "./components/Cart/Cart";
//import Checkout from "./components/CheckoutForm/Checkout/Checkout";

import { BrowserRouter as Router, Route, Routes } from "react-router-dom";

function App() {
  return (
    <Router>
      <div>
        <Navbar />
        <Routes>
          <Route exact path="/" element={<Products />} />
          <Route exact path="/cart" element={<Cart />} />
          <Route exact path="/checkout" element={<Checkout />} />
          <Route exact path="/login" element={<LoginForm />} />
          <Route exact path="/adminPage" element={<AdminPage />} />
          <Route exact path="/profilePage" element={<ProfilePage />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
