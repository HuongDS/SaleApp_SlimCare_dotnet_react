import { Rate, Space, Typography } from "antd";

const { Text } = Typography;

export default function Review({
  rate,
}: {
  rate: number;
}) {
  return (
    <Space align="center" size={12}>
      <Rate
        allowHalf
        disabled
        defaultValue={4.5}
      />
      <Text type="secondary">
        ({rate} đánh giá)
      </Text>
    </Space>
  );
}
