import Carousel from "react-multi-carousel";
import "react-multi-carousel/lib/styles.css"; // bắt buộc khi dùng react-multi-carousel
import { useEffect, useState } from "react";
import { getProductsWithQuantity } from "../../../services/productsService";
import type { Product } from "../../../model/ProductModel";
import ProductComponent from "./ProductComponent";

const responsive = {
  desktop: {
    breakpoint: { max: 4000, min: 1320 },
    items: 4,
  },
  tablet: {
    breakpoint: { max: 1320, min: 1000 },
    items: 3,
  },
  smallTablet: {
    breakpoint: { max: 1000, min: 500 },
    items: 2,
  },
  mobile: {
    breakpoint: { max: 500, min: 0 },
    items: 1,
  },
};

export default function Products() {
  const [products, setProducts] = useState<
    Product[]
  >([]);
  useEffect(() => {
    (async () => {
      const data = await getProductsWithQuantity(
        10
      );
      setProducts(data);
      console.log(data);
    })();
  }, []);

  return (
    <div className="mt-5 mb-5">
      <h2 className="text-center fw-bold fs-1">
        BEST SELLER
      </h2>
      <Carousel
        responsive={responsive}
        autoPlay
        infinite
      >
        {products.map((p) => {
          console.log(p);
          return (
            <ProductComponent
              key={p.id}
              id={p.id}
              img={p.img}
              name={p.name}
              description={p.description}
              price={p.price}
            />
          );
        })}
      </Carousel>
    </div>
  );
}
