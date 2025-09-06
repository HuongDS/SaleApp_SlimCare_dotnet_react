import { PhoneOutlined } from "@ant-design/icons";
import { Button, Col, Row, Space } from "antd";
import Paragraph from "antd/es/typography/Paragraph";
import Title from "antd/es/typography/Title";

export default function HeroSection() {
  return (
    <Row gutter={[24, 24]} align="middle">
      <Col xs={24} md={14}>
        <Space direction="vertical" size={12}>
          <Title
            level={2}
            style={{ marginBottom: 0 }}
          >
            Về Slimcare
          </Title>
          <Paragraph
            style={{
              fontSize: 16,
              opacity: 0.9,
            }}
          >
            Đồng hành cùng bạn trên hành trình
            chăm sóc sức khỏe và sắc đẹp toàn
            diện.
          </Paragraph>
          <Space wrap>
            <Button
              type="primary"
              size="large"
              href="/shop"
            >
              Khám phá sản phẩm
            </Button>
            <Button
              icon={<PhoneOutlined />}
              size="large"
              href="/contact"
            >
              Liên hệ
            </Button>
          </Space>
        </Space>
      </Col>
      <Col xs={24} md={10}>
        <div
          style={{
            height: 220,
            borderRadius: 16,
          }}
        />
      </Col>
    </Row>
  );
}
