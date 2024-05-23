# Capstone Project
This project incorporates C#, Selenium, and Sikuli to test 7 predefined test cases and report on their outcome.
The following website will be used to conduct the test cases.

<a href="https://demowebshop.tricentis.com/">
    <img src="img/readme/TestingWebsite.png" align="center"/>
</a>

## Table Of Content
- [How it Works](#how-it-works)
- [Usage](#usage)
- [Test Cases](#test-cases)
    - [Open Home Page](#open-home-page)
    - [Login to Website](#database-setup)
    - [Select Product Category - Jewelry](#security)
    - [Change Jewelry View]()
    - [Select Create Your Own Jewelry](#database-setup)
    - [Checkout Cart]()
    - [Go to Home Page and Logout]()
- [Configuration](#page-setup)
    - [User Name](#download-the-aimeos-page-tree-t3d-file)
    - [Password](#go-to-the-import-view)

## How It Works
1. The OneTimeSetup function is called and the session, driver, and report objects are created.
2. The test cases are executed/tested and reported.
3. The OneTimeTearDown function is called and the session, driver and report objects are destroyed.

## Usage
Configure the project configuration to use your specified details and run all test cases.

## Test Cases

### Open Home Page
<details><summary><b>Show Detail</b></summary>

1. Install the preset:

    ```sh
    npm install --save-dev size-limit @size-limit/file
    ```

2. Add the `size-limit` section and the `size` script to your `package.json`:

    ```diff
    + "size-limit": [
    +   {
    +     "path": "dist/app-*.js"
    +   }
    + ],
      "scripts": {
        "build": "webpack ./webpack.config.js",
    +   "size": "npm run build && size-limit",
        "test": "vitest && eslint ."
      }
    ```
</details>

## Reports

Size Limit has a [GitHub action] that comments and rejects pull requests based
on Size Limit output.

1. Install and configure Size Limit as shown above.
2. Add the following action inside `.github/workflows/size-limit.yml`

```yaml
name: "size"
on:
  pull_request:
    branches:
      - master
jobs:
  size:
    runs-on: ubuntu-latest
    env:
      CI_JOB_NUMBER: 1
    steps:
      - uses: actions/checkout@v1
      - uses: andresz1/size-limit-action@v1
        with:
          github_token: ${{ secrets.GITHUB_TOKEN }}
```


## Config

### Plugins and Presets

Plugins or plugin presets will be loaded automatically from `package.json`.
For example, if you want to use `@size-limit/webpack`, you can just use
`npm install --save-dev @size-limit/webpack`, or you can use our preset
`@size-limit/preset-big-lib`.

Plugins:

* `@size-limit/file` checks the size of files with Brotli (default), Gzip
  or without compression.
* `@size-limit/webpack` adds your library to empty webpack project
  and prepares bundle file for `file` plugin.
* `@size-limit/webpack-why` adds reports for `webpack` plugin
  about your library is of this size to show the cost of all your
  dependencies.
* `@size-limit/webpack-css` adds css support for `webpack` plugin.
* `@size-limit/esbuild` is like `webpack` plugin, but uses `esbuild`
  to be faster and use less space in `node_modules`.
* `@size-limit/esbuild-why` add reports for `esbuild` plugin
  about your library is of this size to show the cost of all your
  dependencies.
* `@size-limit/time` uses headless Chrome to track time to execute JS.

Plugin presets:

* `@size-limit/preset-app` contains `file` and `time` plugins.
* `@size-limit/preset-big-lib` contains `webpack`, `file`, and `time` plugins.
* `@size-limit/preset-small-lib` contains `esbuild` and `file` plugins.
