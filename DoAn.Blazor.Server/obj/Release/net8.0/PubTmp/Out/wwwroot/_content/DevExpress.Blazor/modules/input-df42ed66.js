import{_ as e}from"./_tslib-6e8ca86b.js";import{D as t,b as s,c as i,d as o,I as n,T as r}from"./text-editor-23666614.js";import{t as d}from"./constants-86572358.js";import{K as a,F as u,D as l}from"./keyboard-navigation-strategy-e72cbdd4.js";import{s as h}from"./lit-element-462e7ad3.js";import{n as c}from"./property-4ec0b52d.js";import{e as p}from"./custom-element-267f9a21.js";class f extends a{constructor(e){super(e.getKeyboardNavigator(),e),this._editor=e}queryItems(){const e=[];this._editor.editBoxElement&&e.push(this._editor.editBoxElement);return u.findFocusableElements(this._editor).filter((e=>e!==this._editor.editBoxElement)).forEach((t=>e.push(t))),e}}var y;!function(e){e.isDisplayFormatDefined="is-display-format-defined",e.isPassword="is-password",e.needSelection="need-selection"}(y||(y={}));const m={...y,...t};let I=class extends s{constructor(){super(...arguments),this.selectionRequested=!1,this.boundOnInputFocusHandler=this.onInputFocusIn.bind(this),this.boundOnInputFocusOutHandler=this.onInputFocusOut.bind(this),this.boundOnBeforeInputHandler=this.onBeforeInput.bind(this),this.boundOnInputKeyUpHandler=this.onInputKeyUp.bind(this),this.needSelection=!1,this.isDisplayFormatDefined=!1,this.isPassword=!1}get shouldProcessFocusIn(){return this.isDisplayFormatDefined||this.selectionRequested}get shouldProcessFocusOut(){return this.isDisplayFormatDefined}get shouldProcessEnter(){return!1}get inputElement(){return this.fieldElement}get shouldProcessFieldTextVersion(){return!this.isPassword&&super.shouldProcessFieldTextVersion}onFieldReady(e,t){e.addEventListener("keyup",this.boundOnInputKeyUpHandler),e.addEventListener("beforeinput",this.boundOnBeforeInputHandler),e.addEventListener("focusin",this.boundOnInputFocusHandler),e.addEventListener("focusout",this.boundOnInputFocusOutHandler),this.initializeKeyboardNavigator(),super.onFieldReady(e,t),t&&this.focused&&this.onInputFocusIn()}onTemplateWithoutInputReady(e){super.onTemplateWithoutInputReady(e),e.addEventListener("focusin",this.boundOnInputFocusHandler),e.addEventListener("focusout",this.boundOnInputFocusOutHandler),e.addEventListener("keyup",this.boundOnInputKeyUpHandler)}onInputFocusIn(){this.shouldProcessFocusIn&&this.processFocusIn()}onInputFocusOut(e){this.shouldProcessFocusOut&&this.processFocusOut(e)}onInputKeyUp(e){this.isReadOnly||this.processKeyUp(e)}onBeforeInput(e){this.processBeforeInput(e)}processKeyUp(e){return!1}processFocusIn(){if(this.fieldElement){const e=this.selectionRequested||this.focused&&this.isAllSelected();this.raiseFocusIn(e),this.selectionRequested=!1}else this.editBoxTemplateElement&&this.raiseFocusIn(!1)}processFocusOut(e){this.raiseFocusOut(this.fieldElementValue)}processBeforeInput(e){return!1}raiseFocusIn(e){this.dispatchEvent(new i(e))}raiseFocusOut(e,t){this.dispatchEvent(new o(e,t))}raiseKeyDown(e){this.dispatchEvent(new n(e))}getFieldElement(){return this.querySelector(`[name="${this.id}"].${r.TextEditInput}`)}selectInputText(e,t){this.fieldElement&&this.fieldElement.setSelectionRange(e,t)}selectAll(){this.fieldElement&&this.focused&&this.fieldElement.select()}onPasswordChanged(){this.isPassword&&(this.fieldElementValue="")}updated(e){super.updated(e),this.rendered&&e.has("isPassword")&&this.onPasswordChanged(),this.rendered&&e.has("needSelection")&&this.selectAll()}focusAndSelectAll(){var e;this.selectionRequested=!0,null===(e=this.fieldElement)||void 0===e||e.focus()}initializeKeyboardNavigator(){this.keyboardNavigator=this.querySelector(l),this.keyboardNavigator&&!this.keyboardNavigator.initialized&&this.keyboardNavigator.initialize(this,this.createKeyboardStrategy())}createKeyboardStrategy(){return new f(this)}getKeyboardNavigator(){return this.keyboardNavigator}focus(e){var t;null===(t=this.fieldElement)||void 0===t||t.focus(e)}};I.shadowRootOptions={...h.shadowRootOptions,delegatesFocus:!0},e([c({type:Boolean,attribute:y.needSelection})],I.prototype,"needSelection",void 0),e([c({type:Boolean,attribute:y.isDisplayFormatDefined})],I.prototype,"isDisplayFormatDefined",void 0),e([c({type:Boolean,attribute:y.isPassword})],I.prototype,"isPassword",void 0),I=e([p(d)],I);const b=Object.freeze({__proto__:null,DxInputEditorAttributes:m,get DxInputEditor(){return I},default:{loadModule:function(){}}});export{m as D,f as I,I as a,b as i};