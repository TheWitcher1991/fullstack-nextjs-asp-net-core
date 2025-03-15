import { ITopic, TopicCard } from '~models/topic'

interface TopicsListProps {
	topics: ITopic[]
}

export default function TopicList({ topics }: TopicsListProps) {
	return topics.map(topic => <TopicCard key={topic.id} topic={topic} />)
}
