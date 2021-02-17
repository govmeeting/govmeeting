"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.mapper = void 0;
var core_1 = require("@automapper/core");
var classes_1 = require("@automapper/classes");
exports.mapper = core_1.createMapper({
    name: 'someName',
    pluginInitializer: classes_1.classes,
});
//# sourceMappingURL=mapper.js.map