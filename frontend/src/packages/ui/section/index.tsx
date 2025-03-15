import { Text, TextProps } from '@gravity-ui/uikit'
import { PropsWithChildren } from 'react'

import { Spacing } from '~packages/ui'

interface SectionProps extends PropsWithChildren {
	variant?: TextProps['variant']
	header?: string
	footer?: string
}

export function Section({
	children,
	header,
	variant = 'header-1',
}: SectionProps) {
	return (
		<div>
			<Text variant={variant}>{header}</Text>
			<Spacing v={'xs'} />
			{children}
		</div>
	)
}
