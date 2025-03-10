'use client'

import { ThemeProvider } from '@gravity-ui/uikit'
import { PropsWithChildren } from 'react'

export default function WithTheme({ children }: PropsWithChildren) {
	return (
		<ThemeProvider theme={'light'}>
			<>{children}</>
		</ThemeProvider>
	)
}
