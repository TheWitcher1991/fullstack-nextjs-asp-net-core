import { Card, Text } from '@gravity-ui/uikit'
import { CSSProperties, PropsWithChildren } from 'react'

import styles from './index.module.scss'

interface FormCardProps extends PropsWithChildren {
	title?: string
	width?: CSSProperties['width']
}

export function FormCard({ children, title, width }: FormCardProps) {
	return (
		<Card
			className={styles.form__card}
			style={{ width, flex: width ? `0 0 ${width}px` : undefined }}
		>
			{title && (
				<Text
					variant={'subheader-3'}
					className={styles.form__card__title}
				>
					{title}
				</Text>
			)}
			<>{children}</>
		</Card>
	)
}
