import { SendOutlined } from "@ant-design/icons";
import {
  Alert,
  Button,
  Card,
  Col,
  Divider,
  Form,
  Rate,
  Space,
} from "antd";
import TextArea from "antd/es/input/TextArea";
import Title from "antd/es/typography/Title";

type ReviewFormValues = {
  rating: number;
  content: string;
};

export default function FeedBack() {
  return (
    <Col span={24}>
      <Divider />
      <Card>
        <Title level={3} style={{ marginTop: 0 }}>
          Đánh giá sản phẩm
        </Title>

        <Form<ReviewFormValues>
          layout="vertical"
          onFinish={() => {
            <Alert
              message="Cảm ơn bạn đã gửi đánh giá!"
              type="success"
              showIcon
            />;
          }}
        >
          <Form.Item
            name="rating"
            label="Mức độ hài lòng"
            rules={[
              {
                required: true,
                message: "Vui lòng chọn số sao",
              },
            ]}
          >
            <Rate />
          </Form.Item>

          <Form.Item
            name="content"
            label="Ý kiến của bạn"
            rules={[
              {
                required: true,
                message: "Vui lòng nhập nội dung",
              },
            ]}
          >
            <TextArea
              rows={4}
              placeholder="Nhập đánh giá của bạn về sản phẩm..."
            />
          </Form.Item>

          <Form.Item>
            <Space>
              <Button
                type="primary"
                htmlType="submit"
                icon={<SendOutlined />}
              >
                Gửi đánh giá
              </Button>
            </Space>
          </Form.Item>
        </Form>
      </Card>
    </Col>
  );
}
