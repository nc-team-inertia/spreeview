/** @type {import('tailwindcss').Config} */

console.log("Where is my root");

module.exports = {
    

    content: [
        "./**/*.{razor,html,cshtml}",
        "./node_modules/flowbite/**/*.js",
    ],
    theme: {
        extend: {
            colors: {
                    //TODO doesnt change by theme

                hBg: 'var(--color-hBg)',
                hFg: 'var(--color-hFg)',

                bBg: 'var(--color-bBg)',
                bFg: 'var(--color-bFg)',
                accent: 'var(--color-accent)',
                ImgContainer: 'var(--color-ImgContainer)',

                fBg: 'var(--color-fBg)',
                fFg: 'var(--color-fFg)',

                brand: { light:"#ffffff", dark:"#000000", red:"#FF0000" } //text-brand-light : #ffffff
            },
        },
        plugins: [
            //require('flowbite/plugin') //TODO not found
        ],
    }
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
