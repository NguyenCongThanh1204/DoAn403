import{_ as t}from"./_tslib-6e8ca86b.js";import{D as e,B as i,c as r,a as s,b as a,d as o,e as d,P as h,Z as n}from"./popup-7729314a.js";import{ThumbDragStartedEvent as l,ThumbDragDeltaEvent as c,ThumbDragCompletedEvent as p}from"./thumb-c80aa4fc.js";import{P as g}from"./point-e4ec110e.js";import{L as m,D as u,R as b,a as f}from"./layouthelper-0c7c89da.js";import{E as x}from"./eventhelper-8570b930.js";import{C as v}from"./custom-events-helper-e7f279d3.js";import{i as j}from"./query-44b9267f.js";import{x as y}from"./lit-element-462e7ad3.js";import{n as D}from"./property-4ec0b52d.js";import{e as H}from"./custom-element-267f9a21.js";import"./rafaction-bba7928b.js";import"./screenhelper-cc818363.js";import"./transformhelper-ebad0156.js";import"./positiontracker-896b964e.js";import"./constants-791d6f9b.js";import"./branch-e081818f.js";import"./capturemanager-43e041e5.js";import"./focushelper-cb993bae.js";import"./logicaltreehelper-7b19cc30.js";import"./portal-8366b474.js";import"./data-qa-utils-8be7c726.js";import"./constants-058ebb50.js";import"./const-90026e45.js";import"./dx-html-element-pointer-events-helper-c53bea3a.js";import"./dom-da46d023.js";import"./browser-d96520d8.js";import"./common-f853e871.js";import"./devices-afeafb19.js";import"./dx-ui-element-0557d3f5.js";import"./lit-element-base-b13b710c.js";import"./dx-license-9ec99b59.js";import"./nameof-factory-64d95f5b.js";import"./focustrap-8a58142c.js";import"./key-f9cbed1b.js";import"./keyboard-navigation-strategy-e72cbdd4.js";import"./focus-utils-405a64a8.js";import"./touch-4bff3f51.js";import"./disposable-d2c2d283.js";import"./dom-utils-c35907a1.js";import"./css-classes-cee8476c.js";const w="dxbl-dropdown",S="data-dropdown-thumb";class C{constructor(t,e){this.width=Math.floor(t),this.height=Math.floor(e)}}class W extends CustomEvent{constructor(t,e){super(W.eventName,{detail:new C(t,e),bubbles:!0,composed:!0,cancelable:!0})}}W.eventName=w+".resizeStarted",v.register(W.eventName,(t=>t.detail));class R extends CustomEvent{constructor(t,e){super(R.eventName,{detail:new C(t,e),bubbles:!0,composed:!0,cancelable:!0})}}R.eventName=w+".resizeCompleted",v.register(R.eventName,(t=>t.detail));class N extends e{constructor(){super(...arguments),this.dragStart=null,this.dragBounds=null,this.dragStartedHandler=this.handleDragStarted.bind(this),this.dragDeltaHandler=this.handleDragDelta.bind(this),this.dragCompletedHandler=this.handleDragCompleted.bind(this),this.dragWidth=0,this.dragHeight=0,this.dragMaxWidth=0,this.dragMaxHeight=0,this.isInDragOperation=!1,this.dragCssStyle=null}get branchType(){return i.DropDown}renderTemplate(){return y`
            <dxbl-branch
                id="branch"
                branch-id="${this.branchId}"
                parent-branch-id="${this.parentBranchId}"
                type="${this.branchType}"
                style="${this.dragCssStyle}">
                <dxbl-dropdown-root
                    id="root"
                    style="${this.rootCssStyle}"
                    ?resizing="${this.resizing}"
                    drop-opposite="${this.actualDropOpposite}"
                    drop-direction="${this.actualDropDirection}"
                    drop-alignment="${this.actualDropAlignment}">
                    ${this.renderDefaultSlot()}
                    ${this.renderAdditionalSlots()}
                    ${this.renderBridgeSlot()}
                </dxbl-dropdown-root>
            </dxbl-branch>
        `}getRootTagName(){return"dxbl-dropdown-root"}connectedCallback(){super.connectedCallback(),this.addEventListener(l.eventName,this.dragStartedHandler),this.addEventListener(c.eventName,this.dragDeltaHandler),this.addEventListener(p.eventName,this.dragCompletedHandler)}disconnectedCallback(){super.disconnectedCallback(),this.removeEventListener(l.eventName,this.dragStartedHandler),this.removeEventListener(c.eventName,this.dragDeltaHandler),this.removeEventListener(p.eventName,this.dragCompletedHandler)}get child(){return this.root}handleDragStarted(t){const e=x.getOriginalSource(t);if(!e)return;if(!e.hasAttribute(S))return;if(!this.child)return;this.lockPlacement(),this.dragStart=new g(t.detail.x,t.detail.y);const i=this.getRestrictBounds(),r=this.getPlacementTargetInterestPoints(this.placement),s=this.actualDropAlignment,a=this.actualDropDirection,o=m.getRelativeElementRect(this.child);this.dragBounds=this.calcResizeRect(i,r,s,a),this.dragMaxWidth=this.dragBounds.width,this.dragMaxHeight=this.dragBounds.height,this.isInDragOperation=!0,this.dragWidth=o.width,this.dragHeight=o.height,this.raiseResizeStarted(this.dragWidth,this.dragHeight)}willUpdate(t){super.willUpdate(t),this.dragCssStyle=this.isInDragOperation?`width: ${u.toPx(this.dragWidth)}; height: ${u.toPx(this.dragHeight)}; max-width: ${u.toPx(this.dragMaxWidth)}; max-height: ${u.toPx(this.dragMaxHeight)};`:null}updated(t){super.updated(t),this.root.offsetWidth<this.root.scrollWidth&&(this.dragWidth=this.root.scrollWidth),this.root.offsetHeight<this.root.scrollHeight&&(this.dragHeight=this.root.scrollHeight)}handleDragDelta(t){const e=x.getOriginalSource(t);if(!e)return;if(!e.hasAttribute(S))return;const i=Math.min(this.dragMaxWidth,this.actualDropDirection===s.Near?t.detail.x-this.offset.x:this.offset.x+this.childSize.width-t.detail.x),o=Math.min(this.dragMaxHeight,this.actualDropAlignment===a.bottom?t.detail.y-this.offset.y:this.offset.y+this.childSize.height-t.detail.y),d=r(this.minWidth,this),h=r(this.minHeight,this);this.dragWidth=d?i>d?i:d:i>0?i:0,this.dragHeight=h?o>h?o:h:o>0?o:0}handleDragCompleted(t){var e,i;const r=x.getOriginalSource(t);r&&r.hasAttribute(S)&&(this.isInDragOperation=!1,this.dragWidth=null!==(e=this.branch.offsetWidth)&&void 0!==e?e:0,this.dragHeight=null!==(i=this.branch.offsetHeight)&&void 0!==i?i:0,this.desiredWidth=u.toPx(this.dragWidth),this.desiredHeight=u.toPx(this.dragHeight),this.unlockPlacement(),this.raiseResizeCompleted(this.dragWidth,this.dragHeight))}calcResizeRect(t,e,i,r){if(r===s.Near){if(i===a.top){return b.intersect(t,f.createFromPoints(e[d.TopLeft],t.topRight))}return b.intersect(t,f.createFromPoints(e[d.BottomLeft],t.bottomRight))}if(i===a.top){return b.intersect(t,f.createFromPoints(e[d.TopRight],t.topLeft))}return b.intersect(t,f.createFromPoints(e[d.BottomRight],t.bottomLeft))}raiseResizeStarted(t,e){this.dispatchEvent(new W(t,e))}raiseResizeCompleted(t,e){this.dispatchEvent(new R(t,e))}calcRenderWidth(){return this.isInDragOperation?null:super.calcRenderWidth()}calcRenderHeight(){return this.isInDragOperation?null:super.calcRenderHeight()}shouldUpdateRootCssStyle(t){return super.shouldUpdateRootCssStyle(t)||t.has("isInDragOperation")||t.has("dragWidth")||t.has("dragHeight")||t.has("dragMaxWidth")||t.has("dragMaxHeight")}createKeyboardNavigationStrategy(){return new o(this.keyboardNavigator,this)}}t([j("#root",!0)],N.prototype,"root",void 0),t([j("#branch")],N.prototype,"branch",void 0),t([D({type:Number,reflect:!1})],N.prototype,"dragWidth",void 0),t([D({type:Number,reflect:!1})],N.prototype,"dragHeight",void 0),t([D({type:Number,reflect:!1})],N.prototype,"dragMaxWidth",void 0),t([D({type:Number,reflect:!1})],N.prototype,"dragMaxHeight",void 0),t([D({type:Boolean,reflect:!1})],N.prototype,"isInDragOperation",void 0),t([D({type:String,reflect:!1})],N.prototype,"dragCssStyle",void 0);let I=class extends N{updated(t){t.has("zIndex")&&this.zIndex&&this.raiseZIndexChange(),super.updated(t)}raiseZIndexChange(){this.updateComplete.then((t=>{this.dispatchEvent(new h(new n(this.zIndex)))}))}};function M(t){if(!t)throw new Error("failed");return t}I=t([H(w)],I);const P={getReference:M,dxDropDownTagName:w,DxDropDownBase:N};export{R as DropDownResizeCompletedEvent,W as DropDownResizeStartedEvent,N as DxDropDownBase,P as default,w as dxDropDownTagName,S as dxDropDownThumbAttribute,M as getReference};