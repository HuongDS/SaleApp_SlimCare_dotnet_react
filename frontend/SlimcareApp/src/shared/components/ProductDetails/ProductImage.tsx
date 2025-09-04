import { Image } from "antd";

export default function ProductImage({
  src,
}: {
  src: string;
}) {
  return (
    <div
      style={{
        width: "80%",
        margin: "0 auto",
        textAlign: "center",
      }}
    >
      <Image src={src}></Image>
    </div>
  );
}
