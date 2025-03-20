import { EmotionCard, IEmotion } from '~models/emotion'

interface EmotionListProps {
	emotions: IEmotion[]
}

export default function EmotionList({ emotions }: EmotionListProps) {
	return emotions.map(emotion => (
		<EmotionCard key={emotion.id} emotion={emotion} />
	))
}
