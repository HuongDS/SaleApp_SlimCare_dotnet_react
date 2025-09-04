import AboutUs from "../shared/components/Home/AboutUs";
import Hero from "../shared/components/Home/Hero";
import Quotes from "../shared/components/Home/Quotes";
import Products from "../shared/components/Products/Products";

export default function HomePage() {
  return (
    <div>
      <Hero />
      <Products />
      <AboutUs />
      <Quotes />
    </div>
  );
}
