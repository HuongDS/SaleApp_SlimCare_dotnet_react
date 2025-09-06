import {
  AimOutlined,
  RiseOutlined,
} from "@ant-design/icons";
import { Card, Col, Row, Space } from "antd";
import Paragraph from "antd/es/typography/Paragraph";
import Title from "antd/es/typography/Title";

export default function MissionAndVision() {
  return (
    <Row gutter={[24, 24]}>
      <Col xs={24} md={12}>
        <Card>
          <Space direction="vertical">
            <Space align="center">
              <AimOutlined
                style={{ fontSize: 24 }}
              />
              <Title
                level={4}
                style={{ margin: 0 }}
              >
                Sứ mệnh
              </Title>
            </Space>
            <Paragraph>
              Mang đến giải pháp chăm sóc an toàn,
              thuận tiện và hiệu quả, giúp bạn
              sống khoẻ – đẹp mỗi ngày.
            </Paragraph>
          </Space>
        </Card>
      </Col>
      <Col xs={24} md={12}>
        <Card>
          <Space direction="vertical">
            <Space align="center">
              <RiseOutlined
                style={{ fontSize: 24 }}
              />
              <Title
                level={4}
                style={{ margin: 0 }}
              >
                Tầm nhìn
              </Title>
            </Space>
            <Paragraph>
              Trở thành thương hiệu chăm sóc sức
              khỏe – sắc đẹp đáng tin cậy tại Việt
              Nam và vươn tầm quốc tế.
            </Paragraph>
          </Space>
        </Card>
      </Col>
    </Row>
  );
}
