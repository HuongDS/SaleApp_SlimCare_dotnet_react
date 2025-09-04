import { Button, Card, Space } from "antd";
import Paragraph from "antd/es/typography/Paragraph";
import Title from "antd/es/typography/Title";

export default function CTA() {
  return (
    <Card style={{ textAlign: "center" }}>
      <Title
        level={4}
        style={{ marginBottom: 8 }}
      >
        Tham gia cộng đồng Slimcare
      </Title>
      <Paragraph>
        Nhận tư vấn miễn phí về dinh dưỡng, luyện
        tập và chăm sóc sắc đẹp.
      </Paragraph>
      <Space wrap>
        <Button
          type="primary"
          size="large"
          href="/shop"
        >
          Bắt đầu ngay
        </Button>
        <Button size="large">
          Liên hệ tư vấn
        </Button>
      </Space>
    </Card>
  );
}
