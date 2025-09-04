import { Badge, Col, Row, Statistic } from "antd";

export default function PriceAndStockStatus({
  price,
  stock,
}: {
  price: number;
  stock: number;
}) {
  return (
    <Row gutter={[16, 16]} align="middle">
      <Col flex="auto">
        <Statistic
          title="Giá"
          value={price}
          precision={0}
          suffix="VND"
          valueStyle={{ fontSize: 28 }}
          formatter={(v) => Number(v).toFixed(3)}
        />
      </Col>
      <Col>
        <Badge
          status={
            stock != 0 ? "success" : "error"
          }
          text={
            stock != 0
              ? `Còn ${stock} sản phẩm`
              : "Hết hàng"
          }
        />
      </Col>
    </Row>
  );
}
