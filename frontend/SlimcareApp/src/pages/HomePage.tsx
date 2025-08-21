import AboutUs from "../shared/components/Home/AboutUs";
import Footer from "../shared/components/Home/Footer";
import Header from "../shared/components/Home/Header";
import Hero from "../shared/components/Home/Hero";
import Quotes from "../shared/components/Home/Quotes";

export default function HomePage() {
  return (
    <div>
      <Header />
      <Hero />
      <AboutUs />
      <Quotes />
      <Footer />
    </div>
  );
}
