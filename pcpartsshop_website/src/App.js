import {
  Products,
  Navbar,
  Cart,
  Checkout,
  LoginForm,
  AdminPage,
  ProfilePage,
  Footer,
} from "./components";

import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import "./App.css";

function App() {
  return (
    <Router>
      <div className="app-container">
        <Navbar />
        <Routes>
          <Route exact path="/" element={<Products />} />
          <Route exact path="/cart" element={<Cart />} />
          <Route exact path="/checkout" element={<Checkout />} />
          <Route exact path="/login" element={<LoginForm />} />
          <Route exact path="/adminPage" element={<AdminPage />} />
          <Route exact path="/profilePage" element={<ProfilePage />} />
        </Routes>
        <Footer />
      </div>
    </Router>
  );
}

export default App;
