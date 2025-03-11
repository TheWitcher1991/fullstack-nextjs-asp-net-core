import { Skeleton } from '@gravity-ui/uikit'

export default function TopicsMostSkeletons() {
	return [...Array(15)].map((_, i) => (
		<Skeleton
			key={i}
			style={{
				width: Math.random() * 30 + 100,
				height: 28,
				borderRadius: 'var(--g-border-radius-m)',
			}}
		/>
	))
}
