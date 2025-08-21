import { Card } from "react-bootstrap";

export default function Quote({
  content,
  author,
}: {
  content: string;
  author: string;
}) {
  return (
    <Card
      className="shadow-sm flex-shrink-0"
      style={{ minWidth: 360 }}
    >
      <Card.Header>Quotes</Card.Header>
      <Card.Body>
        <blockquote className="blockquote mb-0">
          <p className="mb-2 text-break">
            "{content}"
          </p>
          <footer className="blockquote-footer">
            {author}
          </footer>
        </blockquote>
      </Card.Body>
    </Card>
  );
}
