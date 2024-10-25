import globals from "globals";
import pluginJs from "@eslint/js";
import tseslint from "typescript-eslint";

export default [
  { files: ["**/*.{js,mjs,cjs,ts}"], ignores: ["**/*.html"] },

  { languageOptions: { globals: { ...globals.browser, ...globals.node } } },
  pluginJs.configs.recommended,
  ...tseslint.configs.strict,
  {
    rules: {
      // Ejemplo de reglas para asegurarte de que ESLint está monitoreando tu código
      //unescapeLeadingUnderscores: "warn", // Advertencia para variables no utilizadas
      semi: ["error", "always"],
      "@typescript-eslint/explicit-member-accessibility": "error",
      "@typescript-eslint/explicit-function-return-type": "error",
      "@typescript-eslint/adjacent-overload-signatures": "error",
      "@typescript-eslint/member-ordering": [
        "error",
        {
          default: {
            memberTypes: [
              "private-static-field",
              "public-static-field",
              "protected-static-field",

              "private-instance-field",
              "public-instance-field",
              "protected-instance-field",

              "constructor",

              "public-method",
              "protected-method",
              "private-method",

              "public-get",
              "protected-get",
              "private-get",
            ],
            order: "alphabetically",
          },
        },
      ],
    },
  },
];
