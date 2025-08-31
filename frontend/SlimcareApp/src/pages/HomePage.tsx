import AboutUs from "../shared/components/Home/AboutUs";
import Footer from "../shared/components/Home/Footer";
import Header from "../shared/components/Home/Header";
import Hero from "../shared/components/Home/Hero";
import Quotes from "../shared/components/Home/Quotes";
import Products from "../shared/components/Products/Products";

export default function HomePage() {
  return (
    <div>
      <Header />
      <Hero />
      <Products />
      <AboutUs />
      <Quotes />
      <Footer />
    </div>
  );
}
