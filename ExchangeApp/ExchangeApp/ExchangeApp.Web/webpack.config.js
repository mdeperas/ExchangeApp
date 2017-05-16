var webpack = require('webpack');
var path = require('path');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var ExtractTextPlugin = require("extract-text-webpack-plugin");

module.exports = {
    context: path.join(__dirname, 'src'),
    entry:
    {
        polyfill: './polyfill.js',
        vendor: './vendor.js',
        main: './app.js'
    },
    output: {
        path: path.join(__dirname, 'dist'),
        filename: '[name].bundle.js'
    },
    devtool: 'source-map',
    plugins: [
        new HtmlWebpackPlugin({
            template: path.join(__dirname, 'src', 'index.html'),
            inject: 'body',
            hash: true
        }),
        new webpack.optimize.CommonsChunkPlugin(
            {
                name: ['polyfill', 'main', 'vendor']
            }
        ),
        new ExtractTextPlugin("[name].bundle.css"),
        new webpack.DefinePlugin({
            'API_URL' : JSON.stringify("http://localhost:60419/")
         })
    ],
    module: {
        rules: [
            {
                test: /\.js$/,
                include: path.join(__dirname, 'src'),
                loader: "babel-loader"
            },
            {
                test: /\.html$/,
                loader: "html-loader"
            },
            {
                test: /\.scss$/,
                loader: ExtractTextPlugin.extract(["css-loader", 'resolve-url-loader', "sass-loader"]),
            }
        ]
    },
    devServer: {
        stats: 'errors-only',
        historyApiFallback: true,
        overlay: true
    }
};