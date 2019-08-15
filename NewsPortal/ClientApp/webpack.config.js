'use strict';

const path = require('path');
const webpack = require('webpack');

module.exports = {
    entry: "./src/index.jsx",
    mode: "development",
    devtool: "source-map",
    output: {
        filename: "./main.js",
        publicPath: 'public/',
        path: path.resolve(__dirname, "./dist/")
    },
    devServer: {
        contentBase: path.join(__dirname, "dist"),
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
        },
            // {
            //     test: /\.css$/,
            //     use: [
            //         "style-loader",
            //         {
            //             loader: "css-loader",
            //             options: {
            //                 modules: true
            //             }
            //         }
            //     ]
            // },
            // {
            //     test: /\.(png|svg|jpg|gif)$/,
            //     use: ["file-loader"]
            // }
        ]
    }
};