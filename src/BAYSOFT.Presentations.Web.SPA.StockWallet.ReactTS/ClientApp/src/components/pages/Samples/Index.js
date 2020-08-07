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
var reactstrap_1 = require("reactstrap");
var GetSamplesByFilterState = require("../../../store/ActionReducers/Samples");
var Index = /** @class */ (function (_super) {
    __extends(Index, _super);
    function Index() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.state = {
            query: "",
            pageNumber: 1,
            pageSize: 10
        };
        //public componentDidUpdate() {
        //    console.log('Update!');
        //    this.ensureDataFetched();
        //}
        _this.handleQueryChange = function (text) {
            _this.setState({ query: text });
        };
        _this.handleSubmitQuery = function () {
            _this.ensureDataFetched();
        };
        _this.handlePagination = function (number) {
            console.log(number);
            _this.setState({ pageNumber: number });
            _this.ensureDataFetched();
        };
        return _this;
    }
    Index.prototype.componentDidMount = function () {
        console.log('Mount!');
        this.ensureDataFetched();
    };
    Index.prototype.render = function () {
        var _this = this;
        var query = this.state.query;
        return (React.createElement(React.Fragment, null,
            React.createElement("div", { className: "row" },
                React.createElement("div", { className: "col-10" },
                    React.createElement("h4", null, "Samples"),
                    React.createElement("h6", { className: "text-muted" }, "List of samples")),
                React.createElement("div", { className: "col-2" },
                    React.createElement(react_router_dom_1.Link, { className: "btn btn-primary btn-block", to: "/samples/new" }, "New"))),
            React.createElement("hr", null),
            React.createElement("div", { className: "row mb-3" },
                React.createElement("div", { className: "col" },
                    React.createElement(reactstrap_1.InputGroup, null,
                        React.createElement(reactstrap_1.Input, { value: query, onChange: function (e) { return _this.handleQueryChange(e.target.value); } }),
                        React.createElement(reactstrap_1.InputGroupAddon, { addonType: "append" },
                            React.createElement(reactstrap_1.Button, { color: "secondary", onClick: function () { return _this.handleSubmitQuery(); } }, "Search!"))))),
            React.createElement("div", { className: "row" },
                React.createElement("div", { className: "col" }, this.renderTable())),
            React.createElement("div", { className: "row" },
                React.createElement("div", { className: "col" }, this.renderPagenation(this.props.pageSize, this.props.pageNumber, this.props.resultCount, 5))),
            React.createElement("hr", null),
            React.createElement("div", { className: "row" },
                React.createElement("div", { className: "col" },
                    React.createElement(react_router_dom_1.Link, { className: "btn btn-link", to: "/" }, "Back")))));
    };
    Index.prototype.ensureDataFetched = function () {
        console.log(this.state);
        var _a = this.state, pageNumber = _a.pageNumber, pageSize = _a.pageSize, query = _a.query;
        this.props.requestGetSamplesByFilter(pageNumber, pageSize, query);
    };
    Index.prototype.renderTable = function () {
        return (React.createElement("table", { className: 'table table-sm table-striped table-bordered', "aria-labelledby": "tabelLabel" },
            React.createElement("thead", null,
                React.createElement("tr", { className: 'bg-dark text-light' },
                    React.createElement("th", null, "#"),
                    React.createElement("th", null, "Description"),
                    React.createElement("th", { style: { width: 32 } }),
                    React.createElement("th", { style: { width: 32 } }))),
            React.createElement("tbody", null, this.props.samples.map(function (sample) {
                return React.createElement("tr", { key: sample.sampleID },
                    React.createElement("td", null, sample.sampleID),
                    React.createElement("td", null, sample.description),
                    React.createElement("td", null,
                        React.createElement(react_router_dom_1.Link, { className: "btn-link", to: "/samples/edit/" + sample.sampleID }, "Edit")),
                    React.createElement("td", null,
                        React.createElement(react_router_dom_1.Link, { className: "btn-link", to: "/samples/delete/" + sample.sampleID }, "Delete")));
            }))));
    };
    Index.prototype.renderPagenation = function (pageSize, pageNumber, totalItems, paginationRange) {
        var _this = this;
        var totalPages = (totalItems % pageSize == 0) ? (totalItems / pageSize) : (Math.floor(totalItems / pageSize) + 1);
        var pages = [];
        var rangeStart = pageNumber - paginationRange;
        var rangeEnd = pageNumber + paginationRange;
        for (var i = rangeStart; i <= rangeEnd; i++) {
            if (i > 0 && i <= totalPages) {
                pages.push(i);
            }
        }
        var firstActive = pageNumber === 1;
        var lastActive = pageNumber === totalPages;
        return (React.createElement(reactstrap_1.Pagination, { size: "sm", "aria-label": "Page navigation" },
            React.createElement(reactstrap_1.PaginationItem, { disabled: firstActive },
                React.createElement(reactstrap_1.PaginationLink, { first: true, onClick: function () { return _this.handlePagination(1); } })),
            React.createElement(reactstrap_1.PaginationItem, { disabled: firstActive },
                React.createElement(reactstrap_1.PaginationLink, { previous: true, onClick: function () { return _this.handlePagination(pageNumber - 1); } })),
            pages.map(function (number) { return React.createElement(reactstrap_1.PaginationItem, { key: number, active: number == pageNumber },
                React.createElement(reactstrap_1.PaginationLink, { onClick: function () { return _this.handlePagination(number); } }, number)); }),
            React.createElement(reactstrap_1.PaginationItem, { disabled: lastActive },
                React.createElement(reactstrap_1.PaginationLink, { next: true, onClick: function () { return _this.handlePagination(pageNumber + 1); } })),
            React.createElement(reactstrap_1.PaginationItem, { disabled: lastActive },
                React.createElement(reactstrap_1.PaginationLink, { last: true, onClick: function () { return _this.handlePagination(totalPages); } }))));
    };
    return Index;
}(React.PureComponent));
;
exports.default = react_redux_1.connect(function (state) { return state.getSamplesByFilter; }, GetSamplesByFilterState.actionCreators)(Index);
//# sourceMappingURL=Index.js.map