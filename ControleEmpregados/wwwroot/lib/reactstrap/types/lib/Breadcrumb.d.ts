import * as React from 'react';
import { CSSModule } from './utils';

export interface BreadcrumbProps extends React.HTMLAttributes<HTMLElement> {
  [key: string]: any;
  tag?: React.ElementType;
  listTag?: React.ElementType;
  listClassName?: string;
  cssModule?: CSSModule;
}

declare class Breadcrumb extends React.Component<BreadcrumbProps> {}
export default Breadcrumb;
