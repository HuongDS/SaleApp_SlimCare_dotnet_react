import {
  Col,
  Container,
  Navbar,
  Row,
} from "react-bootstrap";
import BrandLink from "./BrandLink";
import Buttons from "./Buttons";
import Features from "./Features";

export default function Header() {
  return (
    <Navbar expand="lg" className="py-2">
      <Container fluid>
        <Navbar.Toggle aria-controls="main-nav" />
        <Navbar.Collapse id="main-nav">
          <Row className="w-100">
            <Col
              xs={3}
              className="d-flex justify-content-start"
            >
              <BrandLink />
            </Col>
            <Col
              xs={6}
              className="d-flex justify-content-center"
            >
              <Features />
            </Col>
            <Col
              xs={3}
              className="d-flex justify-content-end"
            >
              <Buttons />
            </Col>
          </Row>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}
