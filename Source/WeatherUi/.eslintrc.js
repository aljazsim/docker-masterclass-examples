module.exports = {
  root: true,
  env: {
    node: true
  },
  extends: [
    "plugin:vue/essential",
  ],
  parserOptions: {
    ecmaVersion: 2020,
    parser: "@typescript-eslint/parser"
  },
  rules: {
    "no-console": process.env.NODE_ENV === "production" ? "warn" : "off",
    "no-debugger": process.env.NODE_ENV === "production" ? "warn" : "off",
    "semi": ["error", "always"],
    "comma-dangle": ["error", "never"],
    "space-before-function-paren": ["error", { named: "never", anonymous: "always", asyncArrow: "always" }],
    "quotes": ["error", "double"],
    "no-useless-constructor": "off",
    "@typescript-eslint/no-explicit-any": "off",
    "vue/multi-word-component-names": "off"
  },
  overrides: [
    {
      files: [
        "**/__tests__/*.{j,t}s?(x)",
        "**/tests/unit/**/*.spec.{j,t}s?(x)"
      ],
      env: {
        jest: true
      }
    }
  ]
};
