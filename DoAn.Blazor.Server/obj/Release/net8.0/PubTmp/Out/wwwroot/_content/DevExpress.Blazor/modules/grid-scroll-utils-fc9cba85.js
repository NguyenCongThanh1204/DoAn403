import{S as t}from"./screenhelper-cc818363.js";import{a as e,R as i}from"./layouthelper-0c7c89da.js";import{D as n,V as c}from"./dx-scroll-viewer-16dfbee7.js";class l{static calculateHorizontalScrollCorrection(t,e,i){let n=0;const c=t.getBoundingClientRect();for(const t of e){const e=t.getBoundingClientRect(),l=this.getIntersectionRectangle(c,e);if(!l.isEmpty){const t=i?l.left-e.right:l.right-e.left;c.x-=t,n+=t}}return n}static calculateBoundaryItemIndex(t,e,i){const n=Math.ceil(this.getDataAreaViewportHeight(e)),c=i?0:t.itemCount-1;let l=i&&t.selectedItemIndex<=c||!i&&t.selectedItemIndex>=c?c:t.selectedItemIndex,g=this.calculateItemHeight(t,e,l,i);const o=this.isVirtualScrollingEnabled(e)?this.calculateItemAverageHeight(t):void 0,s=i?1:-1;let r=l+s;for(;t.isIndexWithinBoundaries(r)&&(g+=this.getElementHeight(t.getItem(r),o),!(g>n&&l!==t.selectedItemIndex));)l=r,r+=s;return l}static isVirtualScrollingEnabled(t){return void 0!==t.totalItemCount}static isElementInView(t,e){const i=e.getBoundingClientRect(),n=t.getBoundingClientRect();return n.bottom>i.top+n.height&&n.top<i.bottom}static bottomAlignmentRequired(t,e){const i=t.getBoundingClientRect();return e.getBoundingClientRect().bottom-i.bottom<i.height}static calculateItemAverageHeight(t){const e=t.getItem(0);return(t.getItem(t.itemCount-1).getBoundingClientRect().bottom-e.getBoundingClientRect().top)/t.itemCount}static calculateItemHeight(t,e,i,n){const c=t.getItem(i);let l=this.getElementHeight(c);return c&&!this.isOutsideViewportItemRequired(t,e,i,n)&&(l+=this.calculateHeightOffsetValue(c,e,n)),l}static isOutsideViewportItemRequired(t,e,i,n){const c=t.getItem(n?i+1:i-1);if(c){const t=c.getBoundingClientRect(),i=e.getElementsRectangle(e.headerSelector),l=e.getElementsRectangle(e.footerSelector);if(n&&l)return!this.getIntersectionRectangle(t,l).isEmpty;if(!n&&i)return!this.getIntersectionRectangle(t,i).isEmpty;return this.getIntersectionRectangle(t,e.getBoundingClientRect()).height<this.getElementHeight(c)}return!0}static calculateHeightOffsetValue(t,e,i){const l=e.getDataAreaRectangle(),g=l.y,o=l.y+l.height,s=t.getBoundingClientRect();return n.calcScrollOffset(g,o,s.top,s.bottom,i?c.Top:c.Bottom)}static getDataAreaViewportHeight(e){const i=t.viewport(),n=null==e?void 0:e.getRectangle();return n&&n.height<i.height?n.height-this.calcStickyElementsHeight(e):i.height}static calcStickyElementsHeight(t){let e=0;for(const i of this.getStickyElementsRectangles(t))e+=this.getElementRectangleHeight(i);return e}static getStickyElementsRectangles(t){return t?[t.getElementsRectangle(t.headerSelector),t.getElementsRectangle(t.footerSelector)]:[]}static getElementHeight(t,e=0){return t?t.getBoundingClientRect().height:e}static getElementRectangleHeight(t,e=0){return t?t.height:e}static getIntersectionRectangle(t,n){const c=new e(t.x,t.y,t.width,t.height),l=new e(n.x,n.y,n.width,n.height);return i.intersect(c,l)}}export{l as G};