import { Route, Routes } from "react-router-dom";
import HomePage from "./pages/HomePage";
import Shopping from "./pages/Shopping";
import Header from "./shared/components/Home/Header";
import Footer from "./shared/components/Home/Footer";
import AboutUsPage from "./pages/AboutUsPage";
import ProductDetails from "./pages/ProductDetails";

export default function App() {
  return (
    <div className="min-vh-100 d-flex flex-column w-100">
      <Header />
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route
          path="/Shop"
          element={<Shopping />}
        />
        <Route
          path="/about-us"
          element={<AboutUsPage />}
        />
        <Route
          path="/product-details"
          element={<ProductDetails />}
        />
      </Routes>
      <Footer />
    </div>
  );
}
