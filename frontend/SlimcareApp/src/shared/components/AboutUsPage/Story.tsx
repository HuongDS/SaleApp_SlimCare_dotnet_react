import { Card, Col, Row, Timeline } from "antd";
import Paragraph from "antd/es/typography/Paragraph";
import Title from "antd/es/typography/Title";

export default function Story() {
  return (
    <Row gutter={[24, 24]}>
      <Col xs={24} md={12}>
        <Title level={3}>
          Câu chuyện Slimcare
        </Title>
        <Paragraph>
          Slimcare được thành lập từ mong muốn
          giúp mọi người dễ dàng tiếp cận sản phẩm
          chăm sóc sức khỏe, hỗ trợ vóc dáng và
          sắc đẹp. Từ những ngày đầu, chúng tôi
          tập trung chọn lọc sản phẩm uy tín, xây
          dựng cộng đồng khách hàng thân thiết và
          không ngừng cải tiến dịch vụ.
        </Paragraph>
      </Col>
      <Col xs={24} md={12}>
        <Card>
          <Timeline
            items={[
              {
                children:
                  "2023 - Hình thành ý tưởng Slimcare",
              },
              {
                children:
                  "2024 - Ra mắt cửa hàng trực tuyến",
              },
              {
                children:
                  "2025 - Xây dựng cộng đồng tư vấn",
              },
              {
                children:
                  "Tương lai - Mở rộng hệ sinh thái chăm sóc",
              },
            ]}
          />
        </Card>
      </Col>
    </Row>
  );
}
