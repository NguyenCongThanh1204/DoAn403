import{_ as e}from"./_tslib-6e8ca86b.js";import{S as t}from"./single-slot-element-base-e95e208f.js";import{s as i}from"./enumConverter-6047c3ff.js";import{C as r}from"./css-classes-cee8476c.js";import{x as s}from"./lit-element-462e7ad3.js";import{n as a}from"./property-4ec0b52d.js";import{e as l}from"./custom-element-267f9a21.js";import"./data-qa-utils-8be7c726.js";import"./const-90026e45.js";import"./dx-ui-element-0557d3f5.js";import"./lit-element-base-b13b710c.js";import"./dx-license-9ec99b59.js";import"./logicaltreehelper-7b19cc30.js";import"./layouthelper-0c7c89da.js";import"./point-e4ec110e.js";import"./constants-791d6f9b.js";class o{}o.ProgressBar=r.Prefix+"-progress-bar",o.ProgressCircularBar=r.Prefix+"-progress-circular-bar",o.ProgressCircularBarTrack=o.ProgressCircularBar+"-track",o.ProgressCircularBarIndicator=o.ProgressCircularBar+"-indicator",o.ProgressBarLabel=o.ProgressBar+"-label",o.ProgressBarLabelContainer=o.ProgressBarLabel+"-container";class c{static convertRemToPixels(e){return e*parseFloat(getComputedStyle(document.documentElement).fontSize)}static convertToPixels(e){const t=document.createElement("div");t.style.fontSize="1rem",t.style.position="absolute",t.style.visibility="hidden",t.style.width=e,document.body.appendChild(t);const i=t.offsetWidth;return document.body.removeChild(t),i}}var h;!function(e){e[e.Horizontal=0]="Horizontal",e[e.Vertical=1]="Vertical",e[e.Circular=2]="Circular"}(h||(h={}));let u=class extends t{constructor(){super(...arguments),this.value=null,this.visible=!1,this.type=null,this.size="",this.thickness="",this.indeterminate=!1,this.emptyOffset=!1,this.thicknessPixel=0,this.circularSizeObserver=null}get radius(){return this.thicknessPixel?50-this.thicknessPixel/2:50}get isVertical(){return this.type===h.Vertical}get isHorizontal(){return this.type===h.Horizontal}get isCircular(){return this.type===h.Circular}get offset(){return this.emptyOffset?0:this.indeterminate?.7*this.circumference:this.circumference*(100-this.value)/100}get circumference(){return Math.round(2*Math.PI*this.radius)}connectedCallback(){super.connectedCallback(),this.updateSize(),this.style.visibility="visible"}render(){return s`
            <style>
                :host {
                    --dxbl-progress-bar-indicator-width: ${this.isHorizontal?this.value+"%":"100%"};
                    --dxbl-progress-bar-indicator-height: ${this.isVertical?this.value+"%":"100%"};
                }
            </style>
            <slot></slot>
        `}updated(e){super.updated(e),e.has("visible")&&(this.style.display=this.visible?"":"none"),e.has("type")&&this.updateType(),e.has("thickness")&&this.updateThickness(),(e.has("value")||e.has("indeterminate")||e.has("emptyOffset"))&&this.isCircular&&this.updateCircularValue(),(e.has("size")||e.has("type"))&&this.updateSize()}updateSize(){this.calculateSize(),this.updateCircular()}calculateSize(){this.style.width=this.isHorizontal||this.isCircular?this.size:"",this.style.height=this.isVertical||this.isCircular?this.size:"",this.style.setProperty("--dxbl-progress-bar-width",this.style.width),this.style.setProperty("--dxbl-progress-bar-height",this.style.height)}updateType(){this.updateCircular()}updateCircular(){this.isCircular&&(this.updateThickness(),this.updatePercentCircularSize())}updateThickness(){this.style.setProperty("--dxbl-progress-bar-thickness",this.thickness),this.isCircular&&(this.thicknessPixel=c.convertToPixels(this.thickness),this.updateCircularValue(),this.updateCircularLabelSize())}updateCircularValue(){if(!this.isCircular||!this.thicknessPixel)return;const e=this.querySelector(`.${o.ProgressCircularBarTrack}`),t=this.querySelector(`.${o.ProgressCircularBarIndicator}`);e&&t&&(e.setAttribute("r",this.radius.toString()),t.setAttribute("r",this.radius.toString()),t.setAttribute("stroke-dasharray",this.circumference.toFixed(2)),t.setAttribute("stroke-dashoffset",this.offset.toFixed(2)),t.style.display=0===this.value?"none":"")}updatePercentCircularSize(){this.size.indexOf("%")<0?this.unsubscribeCircularSizeObserver():(this.subscribeCircularSizeObserver(),this.updateCircularPercentHeight())}subscribeCircularSizeObserver(){this.circularSizeObserver||(this.circularSizeObserver=new ResizeObserver((()=>this.updateCircularPercentHeight())),this.circularSizeObserver.observe(this))}unsubscribeCircularSizeObserver(){this.circularSizeObserver&&(this.circularSizeObserver.unobserve(this),this.circularSizeObserver=null,this.calculateSize())}updateCircularPercentHeight(){this.style.height=this.offsetWidth+"px",this.updateCircularLabelSize()}updateCircularLabelSize(){const e=(()=>{const e=this.querySelector(`.${o.ProgressBarLabelContainer}`);if(!e)return 0;const t=e.querySelector(".dxbl-image");return t?t.clientWidth+c.convertToPixels(getComputedStyle(e).gap):0})(),t=this.offsetWidth-2*Math.PI*this.thicknessPixel-e;this.style.setProperty("--dxbl-progress-bar-label-width",t.toFixed(2)+"px")}};e([a({type:Number})],u.prototype,"value",void 0),e([a({type:Boolean})],u.prototype,"visible",void 0),e([a({type:h,converter:i(h)})],u.prototype,"type",void 0),e([a()],u.prototype,"size",void 0),e([a()],u.prototype,"thickness",void 0),e([a({type:Boolean})],u.prototype,"indeterminate",void 0),e([a({attribute:"empty-offset",type:Boolean})],u.prototype,"emptyOffset",void 0),u=e([l("dxbl-progress-bar")],u);export{u as DxProgressBar};