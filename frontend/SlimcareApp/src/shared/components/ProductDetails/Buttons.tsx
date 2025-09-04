import {
  ShoppingCartOutlined,
  ThunderboltOutlined,
} from "@ant-design/icons";
import { Button, Col, Space } from "antd";

export default function Buttons({
  stock,
}: {
  stock: number;
}) {
  return (
    <Col xs={24} sm={12}>
      <Space wrap style={{ width: "100%" }}>
        <Button
          type="primary"
          icon={<ShoppingCartOutlined />}
          size="large"
          block
          disabled={stock == 0}
        >
          Thêm vào giỏ
        </Button>
        <Button
          icon={<ThunderboltOutlined />}
          size="large"
          block
          disabled={stock == 0}
        >
          Mua ngay
        </Button>
      </Space>
    </Col>
  );
}
