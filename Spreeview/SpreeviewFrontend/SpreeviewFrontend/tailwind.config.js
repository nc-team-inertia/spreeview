/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./**/*.{razor,html,cshtml}",
        // "./node_modules/flowbite/**/*.js"
    ],
  theme: {
        extend: {
            colors: {
                hFg: 'var(--hFg)',
                hBg: 'var(--hBg)',
                accent: 'var(--accent)',
                container: 'var(--container)',
                mFg: 'var(--mFg)',
                mBg: 'var(--mBg)',
                fFg: 'var(--fFg))',
                fBg: 'var(--fBg)',
                oFg: 'var(--oFg)',
                oBg: 'var(--oBg)',
            },
        },
  },
    plugins: [
        // require('flowbite/plugin')
    ],
}

