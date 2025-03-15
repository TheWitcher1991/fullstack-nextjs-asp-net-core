import { Image } from '~packages/ui'

import styles from './index.module.scss'

interface CardImageProps {
	width: number
	height: number
	src: string
	radius?: number
}

export function CardImage({ width, height, src, radius = 8 }: CardImageProps) {
	return (
		<div
			className={styles.model__image}
			style={{
				width: `${width}px`,
				height: `${height}px`,
				borderRadius: `${radius}px`,
			}}
		>
			<Image width={width} height={height} src={src} alt={''} />
		</div>
	)
}
