import{u as e,v as t,p as o,w as s}from"./popup-7729314a.js";import{d as r}from"./constants-058ebb50.js";import{D as i}from"./popupportal-87b21a6c.js";import{_ as a}from"./_tslib-6e8ca86b.js";import{e as p}from"./custom-element-267f9a21.js";import{s as n,x as m}from"./lit-element-462e7ad3.js";import"./layouthelper-0c7c89da.js";import"./point-e4ec110e.js";import"./constants-791d6f9b.js";import"./rafaction-bba7928b.js";import"./screenhelper-cc818363.js";import"./transformhelper-ebad0156.js";import"./positiontracker-896b964e.js";import"./branch-e081818f.js";import"./property-4ec0b52d.js";import"./capturemanager-43e041e5.js";import"./eventhelper-8570b930.js";import"./focushelper-cb993bae.js";import"./logicaltreehelper-7b19cc30.js";import"./portal-8366b474.js";import"./data-qa-utils-8be7c726.js";import"./const-90026e45.js";import"./dx-html-element-pointer-events-helper-c53bea3a.js";import"./dom-da46d023.js";import"./browser-d96520d8.js";import"./common-f853e871.js";import"./devices-afeafb19.js";import"./dx-ui-element-0557d3f5.js";import"./lit-element-base-b13b710c.js";import"./dx-license-9ec99b59.js";import"./nameof-factory-64d95f5b.js";import"./custom-events-helper-e7f279d3.js";import"./focustrap-8a58142c.js";import"./key-f9cbed1b.js";import"./keyboard-navigation-strategy-e72cbdd4.js";import"./focus-utils-405a64a8.js";import"./touch-4bff3f51.js";import"./disposable-d2c2d283.js";import"./dom-utils-c35907a1.js";import"./css-classes-cee8476c.js";const c="dxbl-modal-root";let d=class extends n{constructor(){super(...arguments),this.slotChangedHandler=this.handleSlotChange.bind(this)}render(){return m`
            <slot @slotchange=${this.slotChangedHandler}></slot>
        `}handleSlotChange(o){const s=o.target.assignedNodes().find((t=>t instanceof e)),r=this.closest(t);r&&(s?(r.notifyDialogConnected(s),r.notifyRootConnected()):(r.notifyDialogDisconnected(),r.notifyRootDisconnected()))}};d=a([p(c)],d);const l=[o,s,t,c,r,i];function j(e){if(!e)throw new Error("failed");return e}const f={getReference:j,registeredComponents:l};export{f as default,j as getReference,l as registeredComponents};