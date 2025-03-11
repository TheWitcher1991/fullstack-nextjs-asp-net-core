import { Metadata } from 'next'
import { ReactNode } from 'react'
import WithProviders from '~providers'

import './globals.scss'

import '@gravity-ui/uikit/styles/fonts.css'

export const metadata: Metadata = {
	title: '',
	description: '',
	robots: 'index, follow',
	openGraph: {
		title: '',
		description: '',
		type: 'website',
	},
	twitter: {
		title: '',
		description: '',
	},
}

export default function RootLayout({
	children,
}: Readonly<{
	children: ReactNode
}>) {
	return (
		<html lang='ru' suppressHydrationWarning>
			<head>
				<script
					crossOrigin='anonymous'
					src='//unpkg.com/react-scan/dist/auto.global.js'
				/>
			</head>
			<body>
				<WithProviders>{children}</WithProviders>
			</body>
		</html>
	)
}
