/// <binding AfterBuild='less' ProjectOpened='watch' />
var gulp = require("gulp"),
    less = require("gulp-less");

gulp.task("copy", function () {
    gulp.src("./bower_components/bootstrap/dist/**").pipe(gulp.dest("./lib/bootstrap"))
    gulp.src("./bower_components/angular/angular*.{js,map}").pipe(gulp.dest("./lib/angular"))
});

gulp.task("less", function () {
    gulp.src("./less/site.less")
    .pipe(less({ compress: true }))
    .pipe(gulp.dest("./less"))
});

gulp.task("watch", function () {
    gulp.watch("./less/*.less", ["less"])
});