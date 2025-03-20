import { Label } from '@gravity-ui/uikit'

import { IEmotion } from '~models/emotion'

import styles from './index.module.scss'

interface EmotionCardProps {
	emotion: IEmotion
	interactive?: boolean
}

export function EmotionCard({ emotion, interactive }: EmotionCardProps) {
	return (
		<Label
			size={'m'}
			theme={'unknown'}
			interactive={interactive}
			className={styles.emotion}
		>
			{emotion.unicode} {emotion.label}
		</Label>
	)
}
