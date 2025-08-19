import { Carousel, Image } from "react-bootstrap";

export default function Hero() {
  return (
    <Carousel>
      <Carousel.Item
        style={{
          overflow: "hidden",
        }}
      >
        <div className="ratio ratio-21x9 overflow-hidden">
          <Image
            src="/images/banner01.jpg"
            style={{
              height: "100%",
              objectFit: "cover",
            }}
          />
        </div>
      </Carousel.Item>
      <Carousel.Item
        style={{
          overflow: "hidden",
        }}
      >
        <div className="ratio ratio-21x9 overflow-hidden">
          <Image
            src="/images/banner04.jpg"
            style={{
              height: "100%",
              objectFit: "cover",
            }}
          />
        </div>
      </Carousel.Item>
      <Carousel.Item
        style={{
          overflow: "hidden",
        }}
      >
        <div className="ratio ratio-21x9 overflow-hidden">
          <Image
            src="/images/banner05.jpg"
            style={{
              height: "100%",
              objectFit: "cover",
            }}
          />
        </div>
      </Carousel.Item>
    </Carousel>
  );
}
