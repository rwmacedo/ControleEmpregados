import * as React from 'react';
import { CSSModule } from './utils';

interface CommonCarouselProps extends React.HTMLAttributes<HTMLElement> {
  [key: string]: any;
  activeIndex?: number;
  keyboard?: boolean;
  pause?: 'hover' | false;
  ride?: 'carousel';
  interval?: number | string | boolean;
  mouseEnter?: () => void;
  mouseExit?: () => void;
  slide?: boolean;
  dark?: boolean;
  fade?: boolean;
  cssModule?: CSSModule;
  enableTouch?: boolean;
}

export interface CarouselProps extends CommonCarouselProps {
  next: () => void;
  previous: () => void;
}

export interface UncontrolledCarouselProps extends CommonCarouselProps {
  items: any[];
  next?: () => void;
  previous?: () => void;
  controls?: boolean;
  indicators?: boolean;
  autoPlay?: boolean;
}

declare class Carousel extends React.Component<CarouselProps> {}
export default Carousel;
