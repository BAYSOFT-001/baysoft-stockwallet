"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_redux_1 = require("react-redux");
var react_router_dom_1 = require("react-router-dom");
var Edit = /** @class */ (function (_super) {
    __extends(Edit, _super);
    function Edit() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Edit.prototype.render = function () {
        return (React.createElement(React.Fragment, null,
            React.createElement("h4", null, "Samples"),
            React.createElement("h6", { className: "text-muted" }, "Edit sample"),
            React.createElement("hr", null),
            React.createElement("div", { className: "row" },
                React.createElement("div", { className: "col" }, "body...")),
            React.createElement("hr", null),
            React.createElement("div", { className: "row" },
                React.createElement("div", { className: "col" },
                    React.createElement(react_router_dom_1.Link, { className: "btn btn-link", to: "/samples" }, "Back")))));
    };
    return Edit;
}(React.PureComponent));
;
exports.default = react_redux_1.connect()(Edit);
//# sourceMappingURL=Edit.js.map