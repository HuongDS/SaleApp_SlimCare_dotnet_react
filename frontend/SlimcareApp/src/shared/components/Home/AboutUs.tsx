import {
  Button,
  Card,
  Col,
  Image,
  Row,
} from "react-bootstrap";

export default function AboutUs() {
  return (
    <div className="mt-5 mb-5">
      <h2 className="text-center fw-bold fs-1">
        ABOUT US
      </h2>
      <br />
      <Card
        style={{
          width: "80%",
          margin: "0 auto",
        }}
      >
        <Row>
          <Col md={4}>
            <Image
              src="/images/chiPhien.png"
              alt="About Slimcare"
              style={{
                width: "100%",
                height: "auto",
              }}
            />
          </Col>
          <Col md={7}>
            <Card.Body
              style={{
                justifyContent: "center",
                display: "flex",
                flexDirection: "column",
              }}
            >
              <Card.Title
                style={{
                  fontSize: "40px",
                  fontWeight: "bold",
                }}
              >
                About Slimcare
              </Card.Title>
              <Card.Text
                style={{ fontSize: "20px" }}
              >
                Slimcare is a leading provider of
                health and wellness solutions,
                focused on helping individuals
                achieve their weight loss and
                fitness goals. Our innovative
                programs combine the latest
                research in nutrition and exercise
                science with personalized support
                to ensure our clients' success.
              </Card.Text>
              <Button variant="primary">
                More Details
              </Button>
            </Card.Body>
          </Col>
        </Row>
      </Card>
    </div>
  );
}
