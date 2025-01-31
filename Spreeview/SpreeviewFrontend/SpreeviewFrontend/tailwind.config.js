/* @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./**/*.{razor,html,cshtml}",
        "./node_modules/flowbite/**/*.js",
        "./**/CustTailwindThemes.css"
    ],
  theme: {
    extend: {},
    colors: {
        hBg: 'var(--color-hBg)',
        hFg: 'var(--color-hFg)',

        bBg: 'var(--color-bBg)',
        bFg: 'var(--color-bFg)',
        accent: 'var(--color-accent)',
        ImgContainer: 'var(--colour-ImgContainer)',

        fBg: 'var(--color-fBg)',
        fFg: 'var(--color-fFg)',
      
  },
    plugins: [
        require('flowbite/plugin')
    ],
}

