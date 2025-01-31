/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./**/*.{razor,html,cshtml}",
        // "./node_modules/flowbite/**/*.js",
        "./**/CustTailwindThemes.css"
    ],
    theme: {
        extend: {
            colors: {
                hBg: 'var(--color-hBg)',
                hFg: 'var(--color-hFg)',

                bBg: 'var(--color-bBg)',
                bFg: 'var(--color-bFg)',
                accent: 'var(--color-accent)',
                ImgContainer: '#FF0000',

        fBg: 'var(--color-fBg)',
        fFg: 'var(--color-fFg)',
      
  },
    plugins: [
        // require('flowbite/plugin')
    ],
}

/* TODO test and implement online https://playcode.io/tailwind

window.tailwind.config = {
  theme: {
    extend: {
      colors: {
        'my-indigo': '#FF0000',
      },
    },
  },
};
    //WORKS when adding to class text-my-indigo ( class='bg-my-indigo' )
*/
