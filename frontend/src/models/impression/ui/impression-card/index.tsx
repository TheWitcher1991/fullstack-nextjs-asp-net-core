import { Card, Text, UserLabel } from '@gravity-ui/uikit'

import EmotionList from '~features/author-list'

import { IImpression } from '~models/impression'

import styles from './index.module.scss'

interface ImpressionCardProps {
	impression: IImpression
}

export function ImpressionCard({ impression }: ImpressionCardProps) {
	return (
		<Card className={styles.book__card} view={'filled'}>
			<UserLabel
				size={'l'}
				avatar={
					'https://media2.giphy.com/avatars/bookmate_esp/GgxEkGxQZQry.png'
				}
				text={`${impression.user.firstName} ${impression.user.lastName}`}
			/>
			<EmotionList emotions={impression.emotions} />
			<Text variant={'body-2'}>{impression.text}</Text>
		</Card>
	)
}
