import { Card } from "antd";
import Meta from "antd/es/card/Meta";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { setProduct } from "../../../redux/productSlice";
import type { Product } from "../../../model/ProductModel";

export default function ProductShopComponent({
  id,
  alt,
  src,
  name,
  price,
  stock,
}: {
  id: number;
  alt: string;
  src: string;
  name: string;
  price: number;
  stock: number;
}) {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  return (
    <Card
      hoverable
      style={{ width: 240 }}
      cover={<img alt={alt} src={src} />}
      onClick={() => {
        const pro: Product = {
          id: id,
          img: src,
          name: name,
          description: alt,
          price: price,
          stock: stock,
        };
        dispatch(setProduct(pro));
        navigate("/product-details");
      }}
    >
      <Meta
        title={name}
        className="text-start mb-1"
      />
      <Meta
        title={price.toFixed(3) + " VND"}
        description={`Stock: ${stock}`}
        className="text-start"
      />
    </Card>
  );
}
