import { Col, Divider, Row, Space } from "antd";
import ProductImage from "../shared/components/ProductDetails/ProductImage";
import { useSelector } from "react-redux";
import type { RootState } from "../redux/store";
import ProductName from "../shared/components/ProductDetails/ProductName";
import Review from "../shared/components/ProductDetails/Review";
import PriceAndStockStatus from "../shared/components/ProductDetails/PriceAndStockStatus";
import Quantity from "../shared/components/ProductDetails/Quantity";
import Buttons from "../shared/components/ProductDetails/Buttons";
import AddingInform from "../shared/components/ProductDetails/AddingInform";
import FeedBack from "../shared/components/ProductDetails/FeedBack";

export default function ProductDetails() {
  const product = useSelector(
    (state: RootState) => state.product.product
  );

  return (
    <Row gutter={[24, 24]}>
      <Col span={12}>
        <ProductImage
          src={product ? product.img : "error"}
        />
      </Col>
      <Col span={12}>
        <Space
          direction="vertical"
          size={8}
          style={{ width: "100%" }}
        >
          <ProductName
            name={product ? product.name : ""}
          />
          <Review rate={128} />
          <PriceAndStockStatus
            price={product ? product.price : 0}
            stock={product ? product.stock : 0}
          />
          <Divider style={{ margin: "12px 0" }} />
          <Row gutter={[12, 12]} align="middle">
            <Quantity
              stock={product ? product.stock : 0}
            />
            <Buttons
              stock={product ? product.stock : 0}
            />
          </Row>
          <AddingInform />
        </Space>
      </Col>
      <FeedBack />
    </Row>
  );
}
