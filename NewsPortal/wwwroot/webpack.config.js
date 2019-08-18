'use strict';

const path = require('path');
const webpack = require('webpack');

module.exports = {
    entry: ["babel-polyfill", "./src/index.jsx"],
    mode: "development",
    devtool: "source-map",
    output: {
        filename: "./main.js",
        path: path.resolve(__dirname, "./public/")
    },
    devServer: {
        contentBase: path.join(__dirname, "public"),
        compress: true,
        port: 9000,
        watchContentBase: true,
        progress: true
    },

    module: {
        rules: [{
            test: /\.m?js$/,
            exclude: /(node_modules|bower_components)/,
            use: {
                loader: "babel-loader"
            }
        },
        {
            test: /\.jsx$/,
            exclude: /(node_modules)/,
            loader: "babel-loader"
        }
        ]
    }
};