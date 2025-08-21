import {
  useEffect,
  useRef,
  useState,
} from "react";
import { QUOTES } from "../../../data/quotes";
import Quote from "./Quote";

export default function Quotes() {
  const wrapRef = useRef<HTMLDivElement>(null); // viewport, scroll event at here
  const stripRef = useRef<HTMLDivElement>(null); // array quotes
  const [atEnd, setAtEnd] = useState(false); // check if at end

  useEffect(() => {
    const wrap = wrapRef.current!; // make sure wrap is not null
    const strip = stripRef.current!; // make sure strip is not null
    if (!wrap || !strip) return; // check if wrap or strip is null

    const onWheel = (e: WheelEvent) => {
      const max =
        strip.scrollWidth - strip.clientWidth; // max scroll width
      const reachEnd =
        Math.ceil(strip.scrollLeft) >= max;
      const atStart = strip.scrollLeft == 0;

      const goingDown = e.deltaY > 0;
      const shouldHijack =
        (goingDown && !reachEnd) ||
        (!goingDown && !atStart);
      if (shouldHijack) {
        e.preventDefault();
        strip.scrollLeft += e.deltaY * 8; // scroll right to left
      }

      // check reach End or not
      const currentPosition =
        Math.ceil(strip.scrollLeft) >= max;
      if (currentPosition !== atEnd)
        setAtEnd(currentPosition);
    };

    wrap.addEventListener("wheel", onWheel, {
      passive: false,
    });
    // {passive: false} allows call preventDefault() to prevent default scrolling
    return () =>
      wrap.removeEventListener("wheel", onWheel);
  }, [atEnd]);
  return (
    <section
      ref={wrapRef}
      className="d-flex align-items-center bg-light mb-3"
    >
      <div
        ref={stripRef}
        className="d-flex flex-row gap-3 px-4"
        style={{
          overflowX: "auto",
          scrollBehavior: "smooth",
          scrollbarWidth: "none",
        }}
      >
        {QUOTES.map((q, i) => (
          <Quote
            content={q.text}
            author={q.author}
            key={i}
          />
        ))}
      </div>
    </section>
  );
}
