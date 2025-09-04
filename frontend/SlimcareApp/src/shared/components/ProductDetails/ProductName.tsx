import { Space, Tag } from "antd";
import Title from "antd/es/typography/Title";

export default function ProductName({
  name,
}: {
  name: string;
}) {
  return (
    <Space wrap size={12} align="center">
      <Title level={2} style={{ margin: 0 }}>
        {name}
      </Title>
      <Tag color="cyan">Chính hãng</Tag>
    </Space>
  );
}
