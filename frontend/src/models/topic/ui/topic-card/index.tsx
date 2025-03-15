import { Label } from '@gravity-ui/uikit'
import { useRouter } from 'next/navigation'

import { ITopic } from '~models/topic'

interface TopicCardProps {
	topic: ITopic
}

export function TopicCard({ topic }: TopicCardProps) {
	const router = useRouter()

	return (
		<Label size={'m'} theme={'clear'} interactive={true}>
			{topic.title}
		</Label>
	)
}
