const path = require('path')

function resolve(dir) {
  return path.join(__dirname, dir)
}

module.exports = {
  productionSourceMap: false,
  configureWebpack: {
    resolve: {
      alias: {
        styles: path.resolve(__dirname, './src/assets/scss')
      }
    }
  }
}
